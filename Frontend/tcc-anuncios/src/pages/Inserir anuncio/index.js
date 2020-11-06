import React, { useState } from "react";
import { useHistory } from "react-router-dom";
import { Link } from "react-router-dom";

import '../../components/Cabecalho/cabecalho.css'
import '../Inserir anuncio/style.css'

import Logo from '../../assets/image/Capturar.PNG'

import { ToastContainer, toast } from "react-toastify";
import 'react-toastify/dist/ReactToastify.css';

import AnuncioAPI from '../../services/anuncioAPI'
const api = new AnuncioAPI();

export default function InserirAnuncio(props){
    const [infos, setInfos] = useState(props.location.state);
    console.log(infos)

    const [titulo, setTitulo] = useState();
    const [descricao, setDescricao] = useState();
    const [tipodeproduto, setTipoDeProduto] = useState();
    const [condicao, setCondicao] = useState();
    const [genero, setGenero] = useState();
    const [marca, setMarca] = useState();
    const [tamanho, setTamanho] = useState();
    const [preco, setPreco] = useState();
    const [estado, setEstado] = useState();
    const [cidade, setCidade] = useState();
    const [cep, setCep] = useState();
    const [imagens, setImagens] = useState();

    const anunciar = async() => {
        try{
            let cepMask = `${cep.substring(0,5)}-${cep.substring(5,8)}`;

            const modelo = {
                Titulo: titulo,
                Descricao: descricao,
                TipoDoProduto: tipodeproduto,
                Condicao: condicao,
                Genero: genero,
                Marca: marca, 
                Tamanho: tamanho,
                Preco: preco,
                Estado: estado,
                Cidade: cidade,
                CEP: cepMask,
                IdUsuario: infos.idUsuario,
                Imagens: imagens
            }
            const resp = await api.inserirAnuncio(modelo);
            toast.success("Anunciado com sucesso");
        }
        catch (e){
            toast.error(e.response.data.mensagem);
        }
    } 

    return(
        <div>
            <div className="cabecalho">
                <div>
                    <Link className="hihi" to={{pathname:"/Home", state: infos}} ><img class="logo" src={Logo} width="180" height="34px" alt=''/></Link>
                </div> 

                <div className="barraPesquisa hihi">
                    <Link to={{pathname:"/Home", state: infos}}>Fazer novas consultas</Link>
                </div>
                
                <div className="meio"> 
                    <Link class="hihi meio" to={{ pathname: "/MeuPerfil", state: infos }}>Meu perfil</Link>
                    <Link class="hihi meio" to={{ pathname: "/MeusAnuncios", state: infos }}>Meus Anuncios</Link>
                    <Link class="hihi meio" to={{ pathname: "/MeusFavoritos", state: infos }}>Meus Favoritos</Link>
                </div>
            </div>

            <h2 className="caca">Cadastrar Anúncio</h2>
            <div className="container">

                <div className="carara">
                    <label className="ciriri">Titulo do Anúncio:</label>
                    <input type="text" placeholder="Ex: Tênis Nike" value={titulo} onChange={e => setTitulo(e.target.value)}></input>
                </div>

                <div className="carara">
                    <label className="ciriri">Descrição:</label>
                    <input type="text" placeholder="Ex: Tênis Nike, tamanho 40, com caixa e nota fiscal" value={descricao} onChange={e => setDescricao(e.target.value)}></input>
                </div>

                <div className="carara">
                    <label className="ciriri">Tipo do produto:</label>
                    <input type="text" value={tipodeproduto} onChange={e => setTipoDeProduto(e.target.value)}></input>
                </div>

                <div className="carara">
                    <label className="ciriri">Condição do produto:</label>
                    <select className="kill" value={condicao} onChange={e => setCondicao(e.target.value)}>
                        <option value="">Condição do produto</option>
                        <option value="Novo">Novo</option>
                        <option value="Usado">Usado</option>
                    </select>
                </div>

                <div className="carara">
                    <label className="ciriri">Gênero:</label>
                    <select className="kill" value={genero} onChange={e => setGenero(e.target.value)}>
                        <option value="">Gênero</option>
                        <option value="Masculino">Masculino</option>
                        <option value="Feminino">Feminino</option>
                        <option value="Unissex">Unissex</option>
                    </select>
                </div>

                <div className="carara">
                    <label className="ciriri">Marca do produto:</label>
                    <input type="text" value={marca} onChange={e => setMarca(e.target.value)}></input>
                </div>

                <div className="carara">
                    <label className="ciriri">Tamanho:</label>
                    <input type="text" placeholder="Ex: 44/GG" value={tamanho} onChange={e => setTamanho(e.target.value)}></input>
                </div>

                <div className="carara">
                    <label className="ciriri">Preço:</label>
                    <input type="number" value={preco} onChange={e => setPreco(e.target.value)}></input>
                </div>

                <div className="cururu">
                    <div className="carara">
                        <label>Estado:</label>
                        <select className="p" value={estado} onChange={e => setEstado(e.target.value)}>
                            <option value="">Estado</option>
                            <option value="AC">Acre</option>
                            <option value="AL">Alagoas</option>
                            <option value="AP">Amapá</option>
                            <option value="AM">Amazonas</option>
                            <option value="BA">Bahia</option>
                            <option value="CE">Ceará</option>
                            <option value="DF">Distrito Federal</option>
                            <option value="ES">Espírito Santo</option>
                            <option value="GO">Goiás</option>
                            <option value="MA">Maranhão</option>
                            <option value="MT">Mato Grosso</option>
                            <option value="MS">Mato Grosso do Sul</option>
                            <option value="MG">Minas Gerais</option>
                            <option value="PA">Pará</option>
                            <option value="PB">Paraíba</option>
                            <option value="PR">Paraná</option>
                            <option value="PE">Pernambuco</option>
                            <option value="PI">Piauí</option>
                            <option value="RJ">Rio de Janeiro</option>
                            <option value="RN">Rio Grande do Norte</option>
                            <option value="RS">Rio Grande do Sul</option>
                            <option value="RO">Rondônia</option>
                            <option value="RR">Roraima</option>
                            <option value="SC">Santa Catarina</option>
                            <option value="SP">São Paulo</option>
                            <option value="SE">Sergipe</option>
                            <option value="TO">Tocantins</option>            
                        </select>
                    </div>

                    <div className="carara">
                        <label className="mimi">Cidade:</label>
                        <input type="text" className="c" value={cidade} onChange={e => setCidade(e.target.value)}></input>
                    </div>

                    <div className="carara">
                        <label className="mimi">CEP: (Números)</label>
                        <input type="text" className="c" value={cep} onChange={e => setCep(e.target.value)}></input>
                    </div>
                </div>

                <div className="cerara">
                    <input type="file" onChange={e => setImagens(e.target.files.[0])} placeholder="Inserir foto" className="form-control-file"></input>
                </div>

                <div className="tem">
                    <button className="tim">Cancelar</button>
                    <button className="tim" onClick={anunciar}>Anúnciar</button>
                </div>
            </div>

            <div className="rodape">
                <div className="tey">
                    <h5>Site criado pelo time TK Soluções de Informática. Todos os direitos reservados</h5>
                </div>
            </div>
        </div>
    )
}