import React, { useState, useEffect } from "react";
import { Link } from "react-router-dom";

import '../../components/Cabecalho/cabecalho.css'
import '../Home/style.css';

import Logo from '../../assets/image/Capturar.PNG'
import menu from '../../assets/image/menu.png'

import { ToastContainer, toast } from "react-toastify";
import 'react-toastify/dist/ReactToastify.css';

import anuncioAPI from '../../services/anuncioAPI';
const api = new anuncioAPI();


export default function Home(props){
    const [infos, setInfos] = useState(props.location.state);
    const [estado, setEstado] = useState('');
    const [cidade, setCidade] = useState('');
    const [genero, setGenero] = useState('');
    const [condicao, setCondicao] = useState('');
    const [barraPesquisa, setBarraPesquisa] = useState('');
    const [anuncios, setAnuncios] = useState([]);

    const consultarAnuncios = async () => {
        try{
            let e = "";
            let ci = "";
            let cond = "";
            let barra = "";
            let g = "";
            if(barraPesquisa == "") {barra = "BarraPesquisa"} else {barra = barraPesquisa};
            if(estado == "") {e = "Estado"} else {e = estado};
            if(cidade == "") {ci = "Cidade"} else {ci = cidade};
            if(genero == "") {g = "Genero"} else {g = genero};
            if(condicao == "") {cond = "Condicao"} else {cond = condicao};
            const resp = await api.consultarAnuncios(barra,e,ci,g,cond);
            setAnuncios(resp);
        }
        catch (e) {
        }
    }

    useEffect(() => {
        consultarAnuncios();
      }, [])

    return(
        <div className="matheus">
            <div className="cabecalho1">

                <nav class="senta">
                    <ul>
                        <li><img src={menu} width="40" height="40px"></img>
                            <ul>
                                <li><Link class="mago" to={{ pathname: "/MeuPerfil", state: infos}}>Meu perfil</Link></li>
                                <li><Link className="mago" to="/" >Sair</Link></li>
                            </ul>
                        </li>
                    </ul>
                </nav>

                <div className="meio"> 
                    <Link class="tango" to={{ pathname: "/MeusAnuncios", state: infos}}>Meus Anuncios</Link>
                    <Link class="tango" to={{pathname: "/MeusFavoritos", state: infos}}>Meus Favoritos</Link>
                </div>
                <div>
                    <Link  class="hihi" to={{pathname: "/Anunciar", state: infos}}><button class="botaoo">Anunciar</button></Link>
                </div>
            </div>


            <div className="pedroga">
               
                <div className="pedrin">

                    <div className="pedrox">
                        <label className="matiolas">Pesquisar:</label>
                        <input className="koko12 form-control" type="text" placeholder="Pesquisar" onChange={(e) => setBarraPesquisa(e.target.value)}></input>
                    </div>

                    <div className="pedrox">
                        <label className="matiolas">Estado:</label>
                        <select className="keliki1 form-control" onChange={(e) => setEstado(e.target.value)}>
                        <option value="">Estado</option>
                            <option value="Acre">Acre</option>
                            <option value="Alagoas">Alagoas</option>
                            <option value="Amapá">Amapá</option>
                            <option value="Amazonas">Amazonas</option>
                            <option value="Bahia">Bahia</option>
                            <option value="Ceará">Ceará</option>
                            <option value="Distrito Federal">Distrito Federal</option>
                            <option value="Espírito Santo">Espírito Santo</option>
                            <option value="Goiás">Goiás</option>
                            <option value="Maranhão">Maranhão</option>
                            <option value="Mato Grosso">Mato Grosso</option>
                            <option value="Mato Grosso do Sul">Mato Grosso do Sul</option>
                            <option value="Minas Gerais">Minas Gerais</option>
                            <option value="Pará">Pará</option>
                            <option value="Paraíba">Paraíba</option>
                            <option value="Paraná">Paraná</option>
                            <option value="Pernambuco">Pernambuco</option>
                            <option value="Piauí">Piauí</option>
                            <option value="Rio de Janeiro">Rio de Janeiro</option>
                            <option value="Rio Grande do Norte">Rio Grande do Norte</option>
                            <option value="Rio Grande do Sul">Rio Grande do Sul</option>
                            <option value="Rondônia">Rondônia</option>
                            <option value="Roraima">Roraima</option>
                            <option value="Santa Catarina">Santa Catarina</option>
                            <option value="São Paulo">São Paulo</option>
                            <option value="Sergipe">Sergipe</option>
                            <option value="Tocantins">Tocantins</option>               
                        </select>
                    </div>

                    <div className="pedrox">
                        <label className="matiolas">Cidade:</label>
                        <input className="koko1 form-control" type="text" onChange={(e) => setCidade(e.target.value)} placeholder="Cidade"></input>
                    </div>

                    <div className="pedrox">
                        <label className="matiolas">Gênero:</label>
                        <select className="keliki3 form-control" onChange={(e) => setGenero(e.target.value)}>
                            <option value="">Gênero</option>
                            <option value="Masculino">Masculino</option>
                            <option value="Feminino">Feminino</option>
                            <option value="Unisex">Unissex</option>
                        </select>
                    </div>

                    <div className="pedrox">
                        <label className="matiolas">Condição:</label>
                        <select className="keliki4 form-control" onChange={(e) => setCondicao(e.target.value)}>
                            <option value="">Condição</option>
                            <option value="Novo">Novo</option>
                            <option value="Usado">Usado</option>
                        </select>
                    </div>
                    <button className="botao1" onClick={consultarAnuncios}>Filtrar</button>
                </div>

                <div className="loco">
                    {anuncios.map(x =>
                        <div className="flow">
                            <div className="quadradin"> 
                                <Link to={{ pathname: "/Anuncio", state: {x,infos}}}>
                                    <div className="ima">
                                        <img src={api.consultarImagem(x.imagens[0].textoImagem)} width="200px" height="200px"></img>
                                    </div>
                                </Link>

                                <div className="alin">
                                    <h5>
                                        <Link to={{ pathname: "/Anuncio", state: {x,infos}}}>
                                            {x.titulo}
                                        </Link>
                                    </h5>
                                    <h6>Preço:&nbsp;{x.preco}</h6>
                                    <h6>Marca:&nbsp;{x.marca}</h6>
                                    <h6>Tamanho:&nbsp;{x.tamanho}</h6>
                                    <h6>Condição:&nbsp;{x.condicao}</h6>
                                    <h6>Genero:&nbsp;{x.genero}</h6>
                                </div>
                            </div> 
                        </div>
                    )}
                </div>
            </div>
        </div>
    )
}