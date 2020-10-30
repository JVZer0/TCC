import React, { useEffect, useState } from "react";
import { useHistory } from "react-router-dom";
import { Link } from "react-router-dom";

import '../../components/Cabecalho/cabecalho.css'
import '../Meus anuncios/style.css'

import Logo from '../../assets/image/Capturar.PNG'

import anuncioAPI from '../../services/anuncioAPI';
const api = new anuncioAPI();


export default function MeusAnuncios(props){
    const navegacao = useHistory();

    const [infos, setInfos] = useState(props.location.state);
    const [meusAnuncios, setMeusAnuncios] = useState([]);

    const anuncioVendido = async (idAnuncio) => {
        try{
            const resp = await api.anuncioVendido(idAnuncio);      
        }
        catch (e){

        }
    }

    const ativarAnuncio = async (idAnuncio) => {
        try{
            const resp = await api.ativarAnuncio(idAnuncio);
        }
        catch (e){

        }
    }

    const consultarMeusAnuncios = async () => {
        try{
            const resp = await api.consultarMeusAnuncios(infos.idUsuario);
            setMeusAnuncios(resp);
        }
        catch (e){

        }
    }
    useEffect(() => {
        consultarMeusAnuncios();
      }, []);

    return(
        <div className="aiai">

            <div className="cabecalho">
                <div>
                    <Link className="hihi" to={{pathname: "/Home", state: infos}} ><img class="logo" src={Logo} src={Logo} width="180" height="34px" alt=''/></Link>
                </div>

                <div className="barraPesquisa hihi">
                    <Link to={{pathname:"/Home", state: infos}}>Fazer novas consultas</Link>
                </div>

                <div className="meio"> 
                    <Link class="hihi meio" to={{ pathname: "/MeuPerfil", state: infos}}>Meu perfil</Link>
                    <Link class="hihi meio" to={{pathname: "/MeusFavoritos", state: infos}}>Meus Favoritos</Link>
                </div>
                <div>
                    <Link  class="hihi" to="/Anunciar"><button class="botao">Anunciar</button></Link>
                </div>
            </div>
            

            <div class="tabela">
                <div className="shit">
                    <table className="table">
                        <thead>
                            <tr>
                                <th>Titulo</th>
                                <th>Preço</th>
                                <th>Data da postagem</th>
                                <th>Situação</th>
                                <th></th>
                                <th></th>
                                <th></th>
                                <th></th>

                            </tr>
                        </thead>

                        <tbody>
                            {meusAnuncios.map(x =>
                                <tr>
                                    <td ><Link to={{ pathname: "/Anuncio", state: {x,infos}}}>{x.titulo}</Link></td>
                                    <td>{x.preco}</td>
                                    <td>{x.dataDePublicacao.substring(0,10)}</td>
                                    <td>{x.situacao}</td>
                                    <td>Editar</td>
                                    <td><Link to={{ pathname: "/ExcluirAnuncio", state: {infos, x}}}>Excluir</Link></td>
                                    <td>
                                        {
                                            x.situacao == "Publicado" 
                                            ? <Link to={{ pathname: "/Desativar", state: {infos, x}}}>Inativar</Link>
                                            : <button className="fanda" onClick={() => ativarAnuncio(x.idAnuncio)}>Ativar</button>
                                        }
                                    </td>
                                    <td><button className="fanda" onClick={() => anuncioVendido(x.idAnuncio)}>Já vendi</button></td>
                                </tr>    
                            )}
                        </tbody>
                    </table>
                </div>
            </div>

            <div className="rodape">
                    <div className="tey">
                        <h4>Site criado pelo time TK Soluções de Informática. Todos os direitos reservados</h4>
                    </div>
            </div>
        </div>
    )
}